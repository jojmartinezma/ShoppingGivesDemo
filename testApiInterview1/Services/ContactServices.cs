using testApiInterview1.Helpers;
using testApiInterview1.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace testApiInterview1.Services
{
    public interface IContactServices
    {
        Task<ApiResponse> CreateContact(Contactcs contactcs);
        Task<ApiResponse> delete(string email);
        Task<ApiResponse> update(Contactcs contact);
        Task<ApiResponse> GetAll();
        Task<ApiResponse> Get(string email);
    }
    public class ContactServices : IContactServices
    {
        private readonly ContactsContext _contactsContext;
        private ApiResponse _response;

        public ContactServices(ContactsContext context)
        {
            this._contactsContext = context;
            this._response = new ApiResponse();
        }
        public async Task<ApiResponse> CreateContact(Contactcs contactcs)
        {
            try
            {
                await this._contactsContext.Contact.AddAsync(contactcs);
                await this._contactsContext.SaveChangesAsync();

                this._response.Data = contactcs;
                this._response.Message = "Contact created!";
            }
            catch(Exception ex)
            {
                this._response.StatusCode = StatusCodes.Status500InternalServerError; ;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        public async Task<ApiResponse> delete(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var element = await this._contactsContext.Contact.Where(c => c.Email == email).FirstOrDefaultAsync();
                    if (element != null)
                    {
                        this._contactsContext.Contact.Remove(element);
                        await this._contactsContext.SaveChangesAsync();
                        this._response.Message = "Contact deletex";
                    }
                    else
                    {
                        this._response.Message = "contact does not exist";
                    }
                }
                else
                {
                    this._response.Message = "Email not found";
                    this._response.StatusCode = StatusCodes.Status404NotFound;
                }

            }
            catch (Exception ex)
            {
                this._response.StatusCode = StatusCodes.Status500InternalServerError;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        public async Task<ApiResponse> Get(string email)
        {
            try
            {
                if(!string.IsNullOrEmpty(email))
                {
                    this._response.Data = await this._contactsContext.Contact.Where(c => c.Email == email).SingleOrDefaultAsync();

                    if(this._response.Data != null)
                    {
                        this._response.Message = "Contact find";
                    }
                    else
                    {
                        this._response.Message = "contact does not exist";
                    }
                }
                else
                {
                    this._response.Message = "contact does not exist";
                }
                
            }
            catch (Exception ex)
            {
                this._response.StatusCode = StatusCodes.Status500InternalServerError; ;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        public async Task<ApiResponse> GetAll()
        {
            try
            {
                this._response.Data = await this._contactsContext.Contact.ToListAsync();
                this._response.Message = "List of all contacts";
            }
            catch (Exception ex)
            {
                this._response.StatusCode = StatusCodes.Status500InternalServerError; ;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        public async Task<ApiResponse> update(Contactcs contact)
        {
            try
            {
                if (!string.IsNullOrEmpty(contact.Email))
                {
                    var contactDb = await this._contactsContext.Contact.Where(c => c.Email == contact.Email).SingleOrDefaultAsync();
                    if(contactDb != null)
                    {
                        contactDb.Name = contact.Name ?? contactDb.Name;
                        contactDb.PhoneNumber = contact.PhoneNumber ?? contactDb.PhoneNumber;
                        await this._contactsContext.SaveChangesAsync();
                        this._response.Message = "Contact Updated";
                    }
                    else
                    {
                        this._response.Message = "contact does not exist";
                    }
                }
                else
                {
                    this._response.Message = "contact does not exist";
                }

            }
            catch (Exception ex)
            {
                this._response.StatusCode = StatusCodes.Status500InternalServerError; ;
                this._response.Message = ex.Message;
            }

            return this._response;
        }
    }
}
