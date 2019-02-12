using DotNetMomma_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Data
{
    public class Data
    {
        public static List<Category> Categories { get; set;}
        public static List<Resource> Resources { get; set; }

        static Data()
        {
            InitData();
        }

        private static void InitData()
        {
            var categories = new List<Category>() {
                new Category(Category.CategoryType.Tools),
                new Category(Category.CategoryType.Training),
                new Category(Category.CategoryType.Kids)
            };
            var resources = new List<Resource>()
            {
                new Resource(1,"Adobe Colors","https://color.adobe.com/explore/?filter=most-popular&time=month","A great resource for picking colors.", Category.CategoryType.Tools),
                new Resource(2,"Colorzilla", "http://www.colorzilla.com/", "A chrome/firefox addin to grap color info using Eyedropper.",Category.CategoryType.Tools),
                new Resource(3,"w3Schools HTML Color Picker","https://www.w3schools.com/colors/colors_picker.asp","w3Schools HTML Color Picker", Category.CategoryType.Tools),
                new Resource(4,"w3Schools HSL Color Calculator", "https://www.w3schools.com/colors/colors_hsl.asp", "w3schools HSL Color Calculator", Category.CategoryType.Tools),
                new Resource(5,"w3Schools HTML Training","https://www.w3schools.com/", "Free HTML Training Resources", Category.CategoryType.Training),
                new Resource(6,"Scratch", "https://scratch.mit.edu/", "Coding platform for kids to create games",Category.CategoryType.Kids)
            };
            Categories = categories;
            Resources = resources;
        }
    }
}