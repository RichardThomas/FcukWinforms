using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using FcukWinforms.Data;
using FcukWinforms.Data.dsInstanceTableAdapters;
using System.Data.SqlClient;

namespace FcukWinforms
{
    public partial class frmGetOrder : Form
    {
        DataTable tOrd;
        DataTable tFit;
        DataTable tCare;
        DataTable tDesc;
        DataTable tImage;
        DataTable tLining;
        dsInstance dsI;
        tInstanceHeaderTableAdapter taH;
        tInstanceDetailTableAdapter taD;
        int headerId = 0;
        public frmGetOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets an order from the AS400 or from SQL, depending on setting of chkUseThisParm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFetchOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string ordToRetrieve = (chkUseThisParm.Checked) ? txtOrderNumber.Text : cboOrderToRetrieveSql.Text;
                OdbcCommand cmd = new OdbcCommand(string.Format("call {0} ({1})", txtOrderDataProc.Text, (chkUseThisParm.Checked) ? txtOrderNumber.Text : ""));

                cmd.Connection = new OdbcConnection(cboAs400Connections.Text);
                cmd.Connection.Open();
                cmd.Prepare();
                OdbcDataReader dr = cmd.ExecuteReader();
                tOrd = new DataTable("myOrderTable");
                tOrd.Load(dr);
                dgvOrder.DataSource = tOrd;

                // FIT data
                cmd.CommandText = string.Format("call {0}", txtFitDataProc.Text);
                cmd.Prepare();
                dr = cmd.ExecuteReader();
                tFit = new DataTable("myFitDataTable");
                tFit.Load(dr);
                int fitCount = tFit.Rows.Count;
                //dgvFit.DataSource = tFit;

                // care instructions
                // FIT data
                cmd.CommandText = string.Format("call {0}", txtCareDataProc.Text);
                cmd.Prepare();
                dr = cmd.ExecuteReader();
                tCare = new DataTable("myCareDataTable");
                tCare.Load(dr);
                int careCount = tCare.Rows.Count;
                dgvCare.DataSource = tCare;

                // special descriptions
                // data
                cmd.CommandText = string.Format("call {0}", txtDescDataProc.Text);
                cmd.Prepare();
                dr = cmd.ExecuteReader();
                tDesc = new DataTable("myDescDataTable");
                tDesc.Load(dr);
                dgvCare.DataSource = tDesc;

                // lining and filling
                cmd.CommandText = string.Format("call {0}", txtLiningDataProc.Text);
                cmd.Prepare();
                dr = cmd.ExecuteReader();
                tLining = new DataTable("myLiningDataTable");
                tLining.Load(dr);

                // write a new instance if an order has been retrieved from AS400
                if (chkUseThisParm.Checked)
                {

                    // write header
                    string instanceName = string.Format("{0}-{1}", txtOrderNumber.Text.Replace("'", ""), DateTime.Now.ToString());
                    using (SqlCommand sqlc = new SqlCommand("INSERT INTO tInstanceHeader (InstanceName, CreatedBy, Status) VALUES(@InstanceName,@CreatedBy, @Status);  select scope_identity()",
                        new SqlConnection(cboSqlServer.Text)))
                    {
                        sqlc.Parameters.AddWithValue("@InstanceName", instanceName);
                        sqlc.Parameters.AddWithValue("@CreatedBy", Environment.UserName);
                        sqlc.Parameters.AddWithValue("@Status", "NEW");
                        sqlc.Connection.Open();

                        int headerId = -1;
                        object return_value = sqlc.ExecuteScalar();
                        if (return_value != null)
                        {
                            int.TryParse(return_value.ToString(), out headerId);
                        }
                        sqlc.CommandText = "INSERT INTO [dbo].[tInstanceDetail] ([InstanceHeader] ,[SkuNumber],[Category],[EAN],[Condition]," +
                            "[StockStatus],[Price],[PriceCurrency],[ProductDescription],[SellerCost],[SellerCostCurrency], " +
                            "[ManufSuggRetailPrice],[ManufSuggRetailPriceCurrency],[ParentSKU],[RelationshipName],[ResellerSilhouette],[AgeGroups],[Brand], " +
                            "[Description],[Gender],[MainColor],[Season],[Size],[SizeRegister],[SpecialDescription],[SupplierColor],[VatType],[OuterFabricMaterial], " +
                            "[WashInstructions],[Lining],[Filling]) " +
                            "VALUES(@InstanceHeader, @SkuNumber, @Category, @EAN, @Condition, @StockStatus, @Price, @PriceCurrency, @ProductDescription, @SellerCost, " +
                            "@SellerCostCurrency, @ManufSuggRetailPrice, @ManufSuggRetailPriceCurrency, @ParentSKU, @RelationshipName, @ResellerSilhouette, @AgeGroups, " +
                            "@Brand, @Description, @Gender, @MainColor, @Season, @Size, @SizeRegister, @SpecialDescription, @SupplierColor, @VatType, " +
                            "@OuterFabricMaterial, @WashInstructions, @Lining, @Filling ) ";
                        foreach (DataRow r in tOrd.Rows)
                        {
                            sqlc.Parameters.Clear();
                            sqlc.Parameters.AddWithValue("@InstanceHeader", headerId);
                            sqlc.Parameters.AddWithValue("@SkuNumber", (string)r["STYLE"]);
                            sqlc.Parameters.AddWithValue("@Category", (string)r["CATEGORY"]);
                            sqlc.Parameters.AddWithValue("@EAN", (string)r["UPCCODE"]);
                            sqlc.Parameters.AddWithValue("@Condition", "NEW");
                            sqlc.Parameters.AddWithValue("@StockStatus", "0");
                            sqlc.Parameters.AddWithValue("@Price", ((decimal)r["WHOLESALEPRICE"]).ToString());
                            sqlc.Parameters.AddWithValue("@PriceCurrency", (string)r["CURRENCY"]);
                            sqlc.Parameters.AddWithValue("@ProductDescription", (string)r["STYLEDESCRIPTION"]);
                            sqlc.Parameters.AddWithValue("@SellerCost", ((decimal)r["WHOLESALEPRICE"]).ToString());
                            sqlc.Parameters.AddWithValue("@SellerCostCurrency", (string)r["CURRENCY"]);
                            sqlc.Parameters.AddWithValue("@ManufSuggRetailPrice", ((decimal)r["SALESPRICEFROMLIST"]).ToString());
                            sqlc.Parameters.AddWithValue("@ManufSuggRetailPriceCurrency", (string)r["CURRENCY"]);
                            sqlc.Parameters.AddWithValue("@ParentSKU", (string)r["STYLE"]);
                            sqlc.Parameters.AddWithValue("@RelationshipName", "STYLE_COLORSIZE");
                            sqlc.Parameters.AddWithValue("@ResellerSilhouette", "");
                            sqlc.Parameters.AddWithValue("@AgeGroups", "");
                            sqlc.Parameters.AddWithValue("@Brand", "FCUK");
                            sqlc.Parameters.AddWithValue("@Description", "FCUK");
                            sqlc.Parameters.AddWithValue("@Gender", (string)r["RANGENAME"]);
                            sqlc.Parameters.AddWithValue("@MainColor", (string)r["COLOURDESC"]);
                            sqlc.Parameters.AddWithValue("@Season", (string)r["SEASON"]);
                            switch ((string)r["SIZE"])
                            {
                                case "10":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ1"]);
                                    break;
                                case "20":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ2"]);
                                    break;
                                case "30":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ3"]);
                                    break;
                                case "40":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ4"]);
                                    break;
                                case "50":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ5"]);
                                    break;
                                case "60":
                                    sqlc.Parameters.AddWithValue("@Size", (string)r["SZ6"]);
                                    break;
                                default:
                                    sqlc.Parameters.AddWithValue("@Size", "UNKNOWN");
                                    break;
                            }


                            sqlc.Parameters.AddWithValue("@SizeRegister", (string)r["SIZE"]);
                            sqlc.Parameters.AddWithValue("@SpecialDescription", getDescription((string)r["STYLE"]));
                            sqlc.Parameters.AddWithValue("@SupplierColor", (string)r["COLOURDESC"]);
                            sqlc.Parameters.AddWithValue("@VatType", "100");
                            sqlc.Parameters.AddWithValue("@OuterFabricMaterial", (string)r["FABRIC"]);
                            sqlc.Parameters.AddWithValue("@WashInstructions", getCareInstructions((string)r["STYLE"]));
                            sqlc.Parameters.AddWithValue("@Lining", getLining((string)r["STYLE"]));
                            sqlc.Parameters.AddWithValue("@Filling", getFilling((string)r["STYLE"]));
                            //sqlc.Connection.Open();
                            sqlc.ExecuteScalar();
                        }
                        MessageBox.Show(string.Format("Instance with id <{0}> written to SQL", headerId));


                        if (sqlc.Connection.State == System.Data.ConnectionState.Open)
                            sqlc.Connection.Close();

                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Message <{0}?>, inner: <{1}>, stack: <{2}>",ex.Message, ex.InnerException, ex.StackTrace), "Error when running SP");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGetOrder_Load(object sender, EventArgs e)
        {
            cboAs400Connections.Items.AddRange(new string[] { Properties.Settings.Default.ConnectionPeover, Properties.Settings.Default.ConnectionLonda });
            cboAs400Connections.SelectedIndex = 1;

            cboSqlServer.Items.AddRange(new string[] { Properties.Settings.Default.FcukIntegrationConnectionStringLIFE_user, Properties.Settings.Default.FcukIntegrationConnectionStringFCUK_user });

            // load combo of old instances
            if (this.dsI == null)
            {
                this.dsI = new dsInstance();
            }
            vInstanceHeaderByDate_descTableAdapter taHcombo = new vInstanceHeaderByDate_descTableAdapter() { Connection = new SqlConnection(cboSqlServer.Text) };
            taHcombo.Fill(this.dsI._vInstanceHeaderByDate_desc);
            cboOrderToRetrieveSql.DataSource = this.dsI._vInstanceHeaderByDate_desc;
            cboOrderToRetrieveSql.DisplayMember = "NameStatus";
            cboOrderToRetrieveSql.ValueMember = "Id";
        }

        private void btnImageSearch_Click(object sender, EventArgs e)
        {
            if (diaImageFolder.ShowDialog() == DialogResult.OK)
            {
                txtImageLocation.Text = diaImageFolder.SelectedPath;
            }
        }

        private void btnXmlCreate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!chkXmlFromSql.Checked)
            {
                if (tOrd != null)
                {
                    try
                    {
                        string savedStyle = "";
                        var ords = from myRows in tOrd.AsEnumerable() select myRows;
                        FcukProducts sty = new FcukProducts();
                        foreach (var o in ords)
                        {
                            string[] images = null;
                            if (savedStyle != (string)o["STYLE"])
                            {
                                // write a Style parent
                                ColorSize parent = new ColorSize();
                                parent.SkuNumber = (string)o["STYLE"];
                                parent.Category = (string)o["RANGENAME"] + "," + (string)o["CATEGORY"];
                                parent.ParentSku = "Parent";
                                parent.Description = (string)o["STYLEDESCRIPTION"];

                                try
                                {
                                    images = getImages((string)o["STYLE"]);
                                    FileInfo fi = new FileInfo(images[0]);
                                    parent.Images.Add(new Image() { ImageFileName = fi.Name.Replace(" ", "") });

                                }
                                catch (Exception)
                                {
                                }
                                sty.ColorSizeVariations.Add(parent);
                                savedStyle = (string)o["STYLE"];
                            }

                            ColorSize colsz = new ColorSize();
                            colsz.SkuNumber = (string)o["STYLE"];
                            colsz.Category = (string)o["RANGENAME"] + "," + (string)o["CATEGORY"];
                            colsz.Ean = (string)o["UPCCODE"];
                            colsz.Condition = "NEW";
                            colsz.StockStatus = "0";
                            colsz.Price = ((decimal)o["WHOLESALEPRICE"]).ToString();
                            colsz.PriceCurrency = (string)o["CURRENCY"];
                            colsz.Description = (string)o["STYLEDESCRIPTION"];
                            colsz.SellerCost = ((decimal)o["WHOLESALEPRICE"]).ToString();
                            colsz.SellerCostCurrency = (string)o["CURRENCY"];
                            colsz.ManufSuggRetailPrice = ((decimal)o["SALESPRICEFROMLIST"]).ToString();
                            colsz.ManufSuggRetailPriceCurrency = (string)o["CURRENCY"];
                            colsz.ParentSku = (string)o["STYLE"];
                            colsz.RelationshipName = "STYLE_COLORSIZE";
                            colsz.ResellerSilhouette = "";
                            colsz.AgeGroups = "";
                            colsz.Brand = "FCUK";
                            colsz.Gender = (string)o["RANGENAME"];
                            colsz.ColorCode = (string)o["COLOR"];
                            colsz.ColorDescription = (string)o["COLOURDESC"];
                            colsz.Season = (string)o["SEASON"];
                            switch ((string)o["SIZE"])
                            {
                                case "10":
                                    colsz.Size = (string)o["SZ1"];
                                    break;
                                case "20":
                                    colsz.Size = (string)o["SZ2"];
                                    break;
                                case "30":
                                    colsz.Size = (string)o["SZ3"];
                                    break;
                                case "40":
                                    colsz.Size = (string)o["SZ4"];
                                    break;
                                case "50":
                                    colsz.Size = (string)o["SZ5"];
                                    break;
                                case "60":
                                    colsz.Size = (string)o["SZ6"];
                                    break;
                                default:
                                    colsz.Size = "UNKNOWN";
                                    break;
                            }


                            colsz.SizeRegister = (string)o["SIZE"];
                            //colsz.SpecialDescription = "SPECIAL DESCRIPTION FROM SOPHIA XLSX";
                            colsz.SpecialDescription = getDescription((string)o["STYLE"]);
                            colsz.SupplierColor = (string)o["COLOURDESC"];
                            colsz.VatType = "100";
                            colsz.OuterFabricMaterial = (string)o["FABRIC"];
                            colsz.WashInstructions = getCareInstructions((string)o["STYLE"]);
                            colsz.Lining = getLining((string)o["STYLE"]); // "LINING";
                            colsz.Filling = getFilling((string)o["STYLE"]); //"FILLING";
                            //colsz.GarmentLength = "dummy length";
                            //colsz.Collar = "dummy collar";
                            //colsz.Fastening = "dummy fastening";
                            //colsz.SleeveLength = "dummy sleeve";
                            //colsz.InsideLeg = "dummy leg";
                            if (images != null && images.Length > 0)
                            {
                                foreach (string i in images)
                                {
                                    FileInfo fi = new FileInfo(i);

                                    colsz.Images.Add(new Image() { ImageFileName = fi.Name });
                                }
                            }
                            sty.ColorSizeVariations.Add(colsz);
                        }

                        // save XML
                        XmlSerializer mySerializer = new XmlSerializer(typeof(FcukProducts));
                        // To write to a file, create a StreamWriter object. 
                        // desired format is: FCUK_Zalando_Products_20200220115345.MAIN.xml
                        StreamWriter myWriter = new StreamWriter(string.Format("c:\\temp\\FCUK_Zalando_Products_{0}.MAIN.xml", DateTime.Now.ToString("yyyyMMddHHmmss")));
                        mySerializer.Serialize(myWriter, sty);
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var serializer = new XmlSerializer(sty.GetType());
                            serializer.Serialize(stringwriter, sty);
                            string myString = stringwriter.ToString();
                            //XmlTreeDisplay(myString);
                        }

                        myWriter.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(string.Format("Message: <{0}>, line: <{1}>", ex.Message, ex.StackTrace), "Making XML from IBM data");
                    }
                }

            }
            else // use SQL data source
            {
                if (dsI == null)
                {
                    dsI = new dsInstance();
                }
                if (taD==null)
                {
                    taD = new tInstanceDetailTableAdapter() { Connection = new SqlConnection(cboSqlServer.Text) , ClearBeforeFill=true};
                }
                if (taH==null)
                {
                    taH = new tInstanceHeaderTableAdapter() { Connection = new SqlConnection(cboSqlServer.Text), ClearBeforeFill=true };
                }
                taH.Fill(dsI.tInstanceHeader);
                taD.FillByHeaderId(dsI.tInstanceDetail, headerId);

                try
                {
                    string savedStyle = "";
                    var ords = from myRows in tOrd.AsEnumerable() select myRows;
                    FcukProducts sty = new FcukProducts();
                    foreach (dsInstance.tInstanceDetailRow r in dsI.tInstanceDetail.Rows)
                    {
                        string[] images = null;
                        if (savedStyle != r.SkuNumber)
                        {
                            // write a Style parent
                            ColorSize parent = new ColorSize();
                            parent.SkuNumber = r.SkuNumber;
                            parent.Category = r.Category;
                            parent.ParentSku = "Parent";
                            parent.Description = r.ProductDescription;

                            try
                            {
                                images = getImages(r.SkuNumber);
                                FileInfo fi = new FileInfo(images[0]);
                                parent.Images.Add(new Image() { ImageFileName = fi.Name.Replace(" ", "") });

                            }
                            catch (Exception)
                            {
                            }
                            sty.ColorSizeVariations.Add(parent);
                            savedStyle = r.SkuNumber;
                        }

                        ColorSize colsz = new ColorSize();
                        colsz.SkuNumber = r.SkuNumber;
                        colsz.Category = r.Category;
                        colsz.Ean = r.EAN;
                        colsz.Condition = r.Condition;
                        colsz.StockStatus = r.StockStatus.ToString();
                        colsz.Price = r.Price.ToString();
                        colsz.PriceCurrency = r.PriceCurrency;
                        colsz.Description = r.ProductDescription;
                        colsz.SellerCost = r.Price.ToString();
                        colsz.SellerCostCurrency = r.PriceCurrency;
                        colsz.ManufSuggRetailPrice = r.ManufSuggRetailPrice.ToString(); // ((decimal)o["SALESPRICEFROMLIST"]).ToString();
                        colsz.ManufSuggRetailPriceCurrency = r.ManufSuggRetailPriceCurrency; // (string)o["CURRENCY"];
                        colsz.ParentSku = r.SkuNumber;
                        colsz.RelationshipName = "STYLE_COLORSIZE";
                        colsz.ResellerSilhouette = r.ResellerSilhouette;
                        colsz.AgeGroups = r.AgeGroups;
                        colsz.Brand = r.Brand;
                        colsz.Gender = r.Gender;
                        colsz.ColorDescription = r.MainColor;
                        colsz.Season = r.Season;
                        colsz.Size = r.Size;
                        colsz.SizeRegister = r.SizeRegister;
                        //switch (r.Size)
                        //{
                        //    case "10":
                        //        colsz.Size = (string)o["SZ1"];
                        //        break;
                        //    case "20":
                        //        colsz.Size = (string)o["SZ2"];
                        //        break;
                        //    case "30":
                        //        colsz.Size = (string)o["SZ3"];
                        //        break;
                        //    case "40":
                        //        colsz.Size = (string)o["SZ4"];
                        //        break;
                        //    case "50":
                        //        colsz.Size = (string)o["SZ5"];
                        //        break;
                        //    case "60":
                        //        colsz.Size = (string)o["SZ6"];
                        //        break;
                        //    default:
                        //        colsz.Size = "UNKNOWN";
                        //        break;
                        //}


                        colsz.SizeRegister = r.SizeRegister;
                        //colsz.SpecialDescription = "SPECIAL DESCRIPTION FROM SOPHIA XLSX";
                        colsz.SpecialDescription = r.SpecialDescription; // getDescription((string)o["STYLE"]);
                        colsz.SupplierColor = r.SupplierColor;
                        colsz.VatType = r.VatType;
                        colsz.OuterFabricMaterial = r.OuterFabricMaterial;
                        colsz.WashInstructions = r.WashInstructions;
                        colsz.Lining = r.Lining;
                        colsz.Filling =r.Filling;
                        //colsz.GarmentLength = "dummy length";
                        //colsz.Collar = "dummy collar";
                        //colsz.Fastening = "dummy fastening";
                        //colsz.SleeveLength = "dummy sleeve";
                        //colsz.InsideLeg = "dummy leg";
                        if (images != null && images.Length > 0)
                        {
                            foreach (string i in images)
                            {
                                FileInfo fi = new FileInfo(i);

                                colsz.Images.Add(new Image() { ImageFileName = fi.Name });
                            }
                        }
                        sty.ColorSizeVariations.Add(colsz);
                    }

                    // save XML
                    XmlSerializer mySerializer = new XmlSerializer(typeof(FcukProducts));
                    // To write to a file, create a StreamWriter object.  
                    StreamWriter myWriter = new StreamWriter(string.Format("c:\\temp\\FCUK_Zalando_Products_{0}.xml", DateTime.Now.ToString("yyyyMMddHHmmss")));
                    mySerializer.Serialize(myWriter, sty);
                    using (var stringwriter = new System.IO.StringWriter())
                    {
                        var serializer = new XmlSerializer(sty.GetType());
                        serializer.Serialize(stringwriter, sty);
                        string myString = stringwriter.ToString();
                        //XmlTreeDisplay(myString);
                    }

                    myWriter.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(string.Format("Message: <{0}>, line: <{1}>", ex.Message, ex.StackTrace), "Making XML from IBM data");
                }

            }
            Cursor.Current = Cursors.Default;
       }


        public void XmlTreeDisplay(string someXml)
        {
            tvXml.Nodes.Clear();

            // xml to string
          


            // Load the XML Document
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(someXml);
                //doc.Load("");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                return;
            }

            ConvertXmlNodeToTreeNode(doc, tvXml.Nodes);
            tvXml.Nodes[0].ExpandAll();
        }

        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {

            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                    break;
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " +
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }
        }


        private string getCareInstructions(string style)
        {
            var cares = from myCares in tFit.AsEnumerable() select myCares;
            string careInstructions = "";
            foreach (var c in cares)
            {
                if ((string)c["STYLE"] == style)
                {
                    careInstructions += (careInstructions != "") ? ", " : "";
                    string w = (string)c["ENGTRIM"];
                    careInstructions += w.Trim(); 
                }
            }
            return careInstructions;
        }

        private string getLining(string style)
        {
            var linings = from myLinings in tLining.AsEnumerable() select myLinings;
            string lining = "";
            foreach (var l in linings)
            {
                if ((string)l["INVENTORY_"] == style)
                {
                    lining += (lining != "") ? ", " : "";
                    string w = (string)l["LINING"];
                    lining += w.Trim();
                }
            }
            return lining;
        }

        private string getFilling(string style)
        {
            var fillings = from myFilling in tLining.AsEnumerable() select myFilling;
            string filling = "";
            foreach (var l in fillings)
            {
                if ((string)l["INVENTORY_"] == style)
                {
                    filling += (filling != "") ? ", " : "";
                    string w = (string)l["FILLING"];
                    filling += w.Trim();
                }
            }
            return filling;
        }

        private string getDescription(string style)
        {
            var descs = from mydescs in tDesc.AsEnumerable() select mydescs;
            string desc = "";
            foreach (var c in descs)
            {
                if ((string)c["STYLE"] == style)
                {
                    desc = (string)c["COPY"];
                    return desc;
                }
            }
            return desc;
        }

        private string[] getImages( string style)
        {
            
            string[] files = Directory.GetFiles(txtImageLocation.Text, string.Format("{0}*", style));
            return files;
        }

        private void btnOpenXmlFile_Click(object sender, EventArgs e)
        {
            if (diaFileXml.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(diaFileXml.FileName);
                ConvertXmlNodeToTreeNode(xmlDoc, tvXml.Nodes);
            }
        }

         private void chkChooseOrder_CheckedChanged(object sender, EventArgs e)
        {
            this.chkChooseOrder.Checked = !chkUseThisParm.Checked;
            

            
        }
    }
}
