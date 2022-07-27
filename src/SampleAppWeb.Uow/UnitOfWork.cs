using SampleAppWeb.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppWeb.Uow
{
    public class UnitOfWork : IDisposable
    {
        protected readonly SchoolDataContext _context;
        private GenericRepository<Student> studentRepository;


        public UnitOfWork(SchoolDataContext context)
        {
            _context = context;        
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if(this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(_context);
                }
                return studentRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
