using FineWoodworkingBasic.Model;

namespace FineWoodworkingBasic.Service
{
    public class AddBrandService
    {
        public Task<ResultMessage> AddBrandAsync(string bName, string bNotes)
        {
            return Task.FromResult(AddBrandAsyncHelper(bName, bNotes));
        }

        private ResultMessage AddBrandAsyncHelper(string bName, string bNotes)
        {


            FineWoodworkingBasic.Model.Brand brand = new FineWoodworkingApp.Model.Brand(bName, bNotes);
            brand.Save();
            return brand.RetrieveSaveMessage();



        }

    }
}

﻿