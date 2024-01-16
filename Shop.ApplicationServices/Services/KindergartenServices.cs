using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopContext _context;

        public KindergartenServices
            (
                ShopContext context
            )
        {
            _context = context;
        }
        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.ModifiedAt = DateTime.Now;

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var domain = new Kindergarten()
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                Teacher = dto.Teacher,


                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,



            };
            _context.Kindergartens.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Kindergarten> GetAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Kindergarten> Delete(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Kindergartens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}


