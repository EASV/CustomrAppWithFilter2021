using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class HatSQLRepository: IHatRepository
    {
        private CustomerAppDBContext _ctx;

        public HatSQLRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Hat> ReadAll()
        {
            return _ctx.Hats
                .Include(h => h.HatType)
                .ToList();
        }

        public List<HatType> ReadAllTypes()
        {
            return _ctx.HatTypes.ToList();
        }

        public List<Brand> ReadAllBrands()
        {
            return _ctx.Brands.ToList();
        }

        public List<Color> ReadAllColors()
        {
            return _ctx.Colors.ToList();
        }

        public Hat Create(Hat hat)
        {
            //Første Hat
            //_ctx.Attach(hat.Brand).State = EntityState.Deleted;
            
            //Anden Hat
            //_ctx.Attach(hat.Brand).State = EntityState.Unchanged;
            /*var brandEntry = _ctx.ChangeTracker.Entries<Brand>()
                .FirstOrDefault(be => be.Entity.Id == hat.Brand.Id);
            if (brandEntry != null)
            {
                brandEntry.State = EntityState.Detached;
            }
            var colorEntry = _ctx.ChangeTracker.Entries<Color>()
                .FirstOrDefault(be => be.Entity.Id == hat.Color.Id);
            if (colorEntry != null)
            {
                colorEntry.State = EntityState.Detached;
            }
            var typeEntry = _ctx.ChangeTracker.Entries<HatType>()
                .FirstOrDefault(be => be.Entity.Id == hat.HatType.Id);
            if (typeEntry != null)
            {
                typeEntry.State = EntityState.Detached;
            }
*/
            /*_ctx.DetachAll();
            _ctx.Attach(hat.Brand);
            _ctx.Attach(hat.Color);
            _ctx.Attach(hat.HatType);
*/
           /* foreach (var entityEntry in _ctx.ChangeTracker.Entries())
            {
                entityEntry.State = EntityState.Detached;
            }*/
            // If Statement
            /*if (_ctx.ChangeTracker.Entries<Brand>()
                    .FirstOrDefault(b => b.Entity.Id == hat.Brand.Id)
                != null)
            {
                _ctx.Entry(hat.Brand).State = EntityState.Modified;
            }
            else
            {
                _ctx.Attach(hat.Brand).State = EntityState.Unchanged;

            }
            
            _ctx.Attach(hat.Color);
            _ctx.Attach(hat.HatType);
            _ctx.Attach(hat.Brand);
            */

            foreach (var entityEntry in _ctx.ChangeTracker.Entries())
            {
                entityEntry.State = EntityState.Detached;
            }

            // hat.Brand = _ctx.Brands.FirstOrDefault(b => b.Id == hat.Brand.Id);
            if (hat.Brand != null && hat.Brand.Id > 0)
            {
                _ctx.Attach(hat.Brand).State = EntityState.Unchanged;
            }
            if (hat.Color != null && hat.Color.Id > 0)
            {
                _ctx.Attach(hat.Color).State = EntityState.Unchanged;
            }
            
            if (hat.HatType != null && hat.HatType.Id > 0)
            {
                _ctx.Attach(hat.HatType).State = EntityState.Unchanged;
            }
            
            var entry = _ctx.Add(hat);
            
            
            _ctx.SaveChanges();
            
            var result = _ctx.Hats.FromSqlInterpolated(
                $"SELECT * FROM Hats WHERE Name = {hat.Name}");

            return entry.Entity;
        }
        public Hat Update(Hat hat)
        {

            /*if (hat.Brand != null)
            {
                var brand = _ctx.ChangeTracker.Entries<Brand>()
                    .FirstOrDefault(b => b.Entity.Id == hat.Brand.Id);
                if (brand != null)
                {
                    brand.State = EntityState.Unchanged;
                }
                else
                {
                    _ctx.Attach(hat.Brand).State = EntityState.Unchanged;
                }
            }
            else
            {
                _ctx.Entry(hat).Reference(h => h.Brand).IsModified = true;
            }*/
            
            
            //Første Hat
            //_ctx.Attach(hat.Brand).State = EntityState.Deleted;
            
            //Anden Hat
            //_ctx.Attach(hat.Brand).State = EntityState.Unchanged;
            //_ctx.ChangeTracker.Entries().FirstOrDefault();
            _ctx.DetachAll();
            
            
            var entry = _ctx.Update(hat);
            _ctx.Entry(hat).Reference(h => h.Brand).IsModified = true;
            _ctx.Entry(hat).Reference(h => h.Color).IsModified = true;
            _ctx.Entry(hat).Reference(h => h.HatType).IsModified = true;
            
            /*_ctx.Entry(hat).Reference(h => h.Brand).IsModified = true;
            _ctx.Entry(hat).Reference(h => h.Color).IsModified = true;
            _ctx.Entry(hat).Reference(h => h.HatType).IsModified = true;*/
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}