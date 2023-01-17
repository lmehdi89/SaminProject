using SaminProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaminProject.Library
{
    public class UnitOfWork: IDisposable
    {
        private DBContext context = new DBContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<BaseInformation> baseInformationRepository;
        private GenericRepository<News> newsRepository;
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<BaseInformation> BaseInformationRepository
        {
            get
            {

                if (this.baseInformationRepository == null)
                {
                    this.baseInformationRepository = new GenericRepository<BaseInformation>(context);
                }
                return baseInformationRepository;
            }
        }
        public GenericRepository<News> NewsRepository
        {
            get
            {

                if (this.newsRepository == null)
                {
                    this.newsRepository = new GenericRepository<News>(context);
                }
                return newsRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}