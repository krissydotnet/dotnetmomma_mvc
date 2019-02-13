using DotNetMomma_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Data
{
    public class ResourcesRepository
    {

        /// <summary>
        /// Returns a collection of resources.
        /// </summary>
        /// <returns>A list of resources.</returns>
        public List<Resource> GetResources()
        {
            return Data.Resources
                .Join(
                    Data.Sections,  // The inner collection
                    e => e.SectionId, // The outer selector
                    a => a.Id, // The inner selector
                    (e, a) => // The result selector
                    {
                        e.Section = a; // Set the resource's Section property
                        return e; // Return the resource
                    }
                    )
                .OrderByDescending(e => e.Name)
                .ThenByDescending(e => e.Id)
                .ToList();
        }

        /// <summary>
        /// Returns a single resource for the provided ID.
        /// </summary>
        /// <param name="id">The ID for the entry to return.</param>
        /// <returns>An entry.</returns>
        public Resource GetResource(int id)
        {
            Resource resource = Data.Resources
                .Where(e => e.Id == id)
                .SingleOrDefault();
            if (resource.Section == null)
            {
                resource.Section = Data.Sections
                    .Where(a => a.Id == resource.SectionId)
                    .SingleOrDefault();
            }
            if (resource.Category == null)
            {
                resource.Category = Data.Categories
                    .Where(a => a.Id == resource.CategoryId)
                    .SingleOrDefault();
            }

            return resource;
        }
        public Resource GetResourceByCategory(int id)
        {
            Resource resource = Data.Resources
                .Where(e => e.CategoryId == id)
                .SingleOrDefault();
            if (resource.Section == null)
            {
                resource.Section = Data.Sections
                    .Where(a => a.Id == resource.SectionId)
                    .SingleOrDefault();
            }
            if (resource.Category == null)
            {
                resource.Category = Data.Categories
                    .Where(a => a.Id == resource.CategoryId)
                    .SingleOrDefault();
            }

            return resource;
        }
        public void AddResource(Resource resource)
        {
            int nextAvailableResourceId = Data.Resources
                .Max(e => e.Id) + 1;
            resource.Id = nextAvailableResourceId;
            Data.Resources.Add(resource);
        }
        public void UpdateResource(Resource resource)
        {
            int resourceIndex = Data.Resources.FindIndex(e => e.Id == resource.Id);
            if (resourceIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a resource with an ID of {0}", resource.Id));

            }
            Data.Resources[resourceIndex] = resource;
        }

        public void DeleteResource(int id)
        {
            int resourceIndex = Data.Resources.FindIndex(e => e.Id == id);

            if (resourceIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a resource with an ID of {0}", id));
            }
            Data.Resources.RemoveAt(resourceIndex);
        }
    }
}