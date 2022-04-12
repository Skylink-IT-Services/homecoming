﻿using homecoming.api.Abstraction;
using homecoming.api.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace homecoming.api.Repo
{
    public class BusinessRepo : IDataStore<Business>
    {
        HomecomingDbContext context;
        IWebHostEnvironment webHost;
        public BusinessRepo(IWebHostEnvironment env,HomecomingDbContext db)
        {
            webHost = env;
            context = db;
        }
        public void Add(Business Params)
        {
            if (Params.ImageFile != null)
            {
                Params.CoverPhotoUrl = UploadCoverPhoto(Params.ImageFile);
            }
            Business business = new Business()
            {
                BusinessName = Params.BusinessName,
                CoverPhotoUrl = Params.CoverPhotoUrl,
                Tel_No = Params.Tel_No,
                Email = Params.Email,
                AddressLine1 = Params.AddressLine1,
                City = Params.City,
                Zipcode = Params.Zipcode,
                Province = Params.Province,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedOn = null
            };

            context.Businesses.Add(business);
            context.SaveChanges();
        }

        public List<Business> FindAll()
        {
            return context.Businesses.ToList();
        }

        public Business GetById(int id)
        {
            return context.Businesses.SingleOrDefault(o => o.BusinessId.Equals(id));
        }

        public void RemoveById(int id)
        {
            Business business =  context.Businesses.SingleOrDefault(o => o.BusinessId.Equals(id));
            context.Businesses.Remove(business);
            context.SaveChanges();
        }

        public void Update(int id, Business Params)
        {
            Business business = context.Businesses.SingleOrDefault(o => o.BusinessId.Equals(id));
            if(business != null)
            {
                business.BusinessName = Params.BusinessName;
                business.Tel_No = Params.Tel_No;
                business.Email = Params.Email;
                business.AddressLine1 = Params.AddressLine1;
                business.City = Params.City;
                business.Zipcode = Params.Zipcode;
                business.Province = Params.Province;
                business.IsActive = Params.IsActive;
                Params.UpdatedOn = DateTime.Now;
            }

            context.Businesses.Attach(business);
            context.Entry(business).State = EntityState.Modified;
            context.SaveChanges();
        }

        private string UploadCoverPhoto(IFormFile file)
        {

            string fileName = null;
            try
            {
                if (file != null)
                {
                    string uploadDir = Path.Combine(webHost.WebRootPath, "Uploads\\Thumbnails");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                }
            }
            catch (Exception si)
            {

                Debug.WriteLine(si.Message);
            }
            return fileName;
        }
    }
}
