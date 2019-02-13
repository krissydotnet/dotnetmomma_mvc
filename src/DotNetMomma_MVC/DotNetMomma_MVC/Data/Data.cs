using DotNetMomma_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Data
{
    public class Data
    {
        public static List<Section> Sections { get; set; }
        public static List<SubCategory> SubCategories { get; set; }
        public static List<Category> Categories { get; set;}
        public static List<Resource> Resources { get; set; }

        static Data()
        {
            InitData();
        }

        private static void InitData()
        {
            var sections = new List<Section>() {
                new Section(Section.SectionType.Tools),
                new Section(Section.SectionType.Training),
                new Section(Section.SectionType.Kids)
            };
            var categories = new List<Category>() {
                new Category(Category.CategoryType.Design_Tools),
                new Category(Category.CategoryType.Code_Editors),
                new Category(Category.CategoryType.Communities),
                new Category(Category.CategoryType.Code_Validators),
                new Category(Category.CategoryType.Online_Guides),
                new Category(Category.CategoryType.Cheat_Sheet),
                new Category(Category.CategoryType.Free_Resources),
                new Category(Category.CategoryType.Style_Guides),
                new Category(Category.CategoryType.Games),
                new Category(Category.CategoryType.Paid_Resources),
                new Category(Category.CategoryType.Tutorials),
                new Category(Category.CategoryType.Design_Tools),
                new Category(Category.CategoryType.Miscellaneous),
            };
            var resources = new List<Resource>()
            {
                new Resource(1,"Adobe Colors","https://color.adobe.com/explore/?filter=most-popular&time=month","A great resource for picking colors.", Section.SectionType.Tools, Category.CategoryType.Design_Tools,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.Web_Design, SubCategory.SubCategoryType.HTML, SubCategory.SubCategoryType.CSS }),
                new Resource(2,"Colorzilla", "http://www.colorzilla.com/", "A chrome/firefox addin to grap color info using Eyedropper.",Section.SectionType.Tools, Category.CategoryType.Design_Tools,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.Web_Design, SubCategory.SubCategoryType.HTML, SubCategory.SubCategoryType.CSS }),
                new Resource(3,"w3Schools HTML Color Picker","https://www.w3schools.com/colors/colors_picker.asp","w3Schools HTML Color Picker", Section.SectionType.Tools, Category.CategoryType.Design_Tools,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.Web_Design, SubCategory.SubCategoryType.HTML, SubCategory.SubCategoryType.CSS }),
                new Resource(4,"w3Schools HSL Color Calculator", "https://www.w3schools.com/colors/colors_hsl.asp", "w3schools HSL Color Calculator", Section.SectionType.Tools, Category.CategoryType.Design_Tools,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.Web_Design, SubCategory.SubCategoryType.HTML, SubCategory.SubCategoryType.CSS }),
                new Resource(5,"w3Schools HTML Training","https://www.w3schools.com/", "Free HTML Training Resources", Section.SectionType.Training, Category.CategoryType.Free_Resources,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.HTML }),
                new Resource(6,"Scratch", "https://scratch.mit.edu/", "Coding platform for kids to create games",Section.SectionType.Kids,Category.CategoryType.Miscellaneous,
                    new List<SubCategory.SubCategoryType> {SubCategory.SubCategoryType.Coding }),
            };
            Sections = sections;
            Resources = resources;
            Categories = categories;
        }
    }
}