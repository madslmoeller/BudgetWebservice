using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Windows.UI.Popups;
using BudgetManager.Model;
using BudgetMVVM.Model;
using Newtonsoft.Json;

class PersistenceFacade
{
    const string ServerUrl = "http://localhost:38421";
    HttpClientHandler handler;

    public PersistenceFacade()
    {
        handler = new HttpClientHandler();
        handler.UseDefaultCredentials = true;
    }

    #region Invoice Jon
    public List<Invoice> GetInvoices()
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync("api/Invoices").Result;

                if (response.IsSuccessStatusCode)
                {
                    var invoiceList = response.Content.ReadAsAsync<IEnumerable<Invoice>>().Result;
                    return invoiceList.ToList();
                }
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }

    public bool SaveInvoice(Invoice i)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                string jsonInvoice = JsonConvert.SerializeObject(i);

                StringContent content = new StringContent(jsonInvoice, Encoding.UTF8, "Application/json");
                var response = client.PostAsync("api/Invoices/", content).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        return false;
    }

    public bool DeleteInvoice(Invoice i)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.DeleteAsync("api/Invoices/" + i.Id).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        return false;
    }
    #endregion

    #region MainCategory Bipin
    public List<MainCatagory> GetCatagories()
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync("api/MainCategories").Result;


                if (response.IsSuccessStatusCode)
                {
                    var MainCataoryList = response.Content.ReadAsAsync<IEnumerable<MainCatagory>>().Result;
                    return MainCataoryList.ToList();
                }


            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }

    public bool DeleteCatagories(MainCatagory del)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                //StringContent content = new StringContent(jsonInvoice, Encoding.UTF8, "Application/json");
                var response = client.DeleteAsync("api/MainCategories/" + del.Id).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        return false;
    }

    public async void SaveCategory(MainCatagory cat)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = client.GetAsync("api/MainCategories").Result;


                if (response.IsSuccessStatusCode)
                {
                    string uhjson = JsonConvert.SerializeObject(cat);

                    StringContent content = new StringContent(uhjson, Encoding.UTF8, "Application/json");

                    var updateResponse = client.PostAsync($"api/MainCategories/{cat.Id}", content).Result;
                }


            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
    #endregion

    #region SubCategory Nikolai
    public List<SubCategory> GetSubCategory()
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync("api/Invoices").Result;


                if (response.IsSuccessStatusCode)
                {
                    var SubCategoryList = response.Content.ReadAsAsync<IEnumerable<BudgetMVVM.Model.SubCategory>>().Result;
                    return SubCategoryList.ToList();
                }


            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }

    public bool SaveSubCategory(SubCategory i)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                string JsonSubCategory = JsonConvert.SerializeObject(i);
                //jsonInvoice = jsonInvoice.Remove()

                StringContent content = new StringContent(JsonSubCategory, Encoding.UTF8, "Application/json");
                var response = client.PostAsync("api/SubCategory/", content).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        return false;
    }

    public bool DeleteSubCategory(SubCategory i)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {


                var response = client.DeleteAsync("api/SubCategory/" + i.Id).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        return false;
    }

    #endregion

    #region LineItem Mads
    public List<LineItem> GetLineItems()
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync("api/LineItems").Result;

                if (response.IsSuccessStatusCode)
                {
                    var lineItemList = response.Content.ReadAsAsync<IEnumerable<LineItem>>().Result;
                    return lineItemList.ToList();
                }

            }

            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }

    public bool SaveLineItem(LineItem l)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                string jsonLineItem = JsonConvert.SerializeObject(l);

                StringContent content = new StringContent(jsonLineItem, Encoding.UTF8, "Application/json");
                var response = client.PostAsync("api/LineItems/", content).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }

        }
        return false;
    }

    public bool DeleteLineItem(LineItem l)
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.DeleteAsync("api/LineItems/" + l.Id).Result;
                return (response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return false;
        }
    }
    #endregion


    #region Account Jon
    public List<Account> GetAccountsCurrentYear()
    {
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync("api/AccountsCurrentYear").Result;

                if (response.IsSuccessStatusCode)
                {
                    var accountsList = response.Content.ReadAsAsync<IEnumerable<Account>>().Result;
                    return accountsList.ToList();
                }
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }
    #endregion
}
