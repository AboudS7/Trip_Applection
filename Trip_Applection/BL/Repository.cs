using Trip_Applection.Models;

namespace Trip_Applection.BL
{
    public class Repository<T> : IRepostry<T> where T : class
    {
        TravelsContext context = new TravelsContext();
        public T Update(T entity)
        {
            try
            {
                var res = context.Update(entity);
                context.SaveChanges();
                return res.Entity as T;

            }
            catch (Exception ex)
            {
                return default(T);
            }

        }
        public T Create(T entity)
        {
            try
            {
                var result=context.Add(entity);
                context.SaveChanges();
                return result.Entity as T;

            }
            catch (Exception ex)
            {
                return default(T);
            }
            
        }

        public T Delete(int id)
        {
            var result = GetById(id);
            context.Remove(result);
            context.SaveChanges();
            return result ;
        }

        public List<T> GetAll()
        {
            var result = context.Set<T>().ToList();
            return result;
        }

        public T GetById(int id)
        {
            try {
                var result = context.Find<T>(id);
                return result ;
            }
            catch(Exception ex)
            {
                return default (T);
            }
        }

      
    }
}
