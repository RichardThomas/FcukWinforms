using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcukWinforms
{
    public class FcukProducts
    {

        public List<ColorSize> ColorSizeVariations { get; set; }


        public FcukProducts()
        {
            this.ColorSizeVariations = new List<ColorSize>();
        }
    }
    public class ColorSize
    {
        public string SkuNumber { get; set; }
        public string Category { get; set; }
        public string Ean { get; set; }
        public string Condition { get; set; }
        public string StockStatus { get; set; }
        public string Price { get; set; }
        public string PriceCurrency { get; set; }
        public string Description { get; set; }
        public string SellerCost { get; set; }
        public string SellerCostCurrency { get; set; }
        public string ManufSuggRetailPrice { get; set; }
        public string ManufSuggRetailPriceCurrency { get; set; }
        public string ParentSku { get; set; }
        public string RelationshipName { get; set; }
        public string ResellerSilhouette { get; set; }
        public string AgeGroups { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string ColorCode { get; set; }
        public string ColorDescription { get; set; }
        public string Season { get; set; }
        public string Size { get; set; }
        public string SizeRegister { get; set; }
        public string SpecialDescription { get; set; }
        public string SupplierColor { get; set; }
        public string VatType { get; set; }
        public string OuterFabricMaterial { get; set; }
        public string WashInstructions { get; set; }
        public string Lining { get; set; }
        public string Filling { get; set; }
        //public string GarmentLength { get; set; }
        //public string Collar { get; set; }
        //public string Fastening { get; set; }
        //public string SleeveLength { get; set; }
        //public string InsideLeg { get; set; }

        public List<Image> Images { get; set; }

        public ColorSize() => this.Images = new List<Image>();
    }

    public class Image
    {
        public string ImageFileName { get; set; }
        public string ImageNumber { get; set; }
    }
}
