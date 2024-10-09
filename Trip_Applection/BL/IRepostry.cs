namespace Trip_Applection.BL
{
    public interface IRepostry <T> where T : class
    {
       List<T> GetAll();
       T Create(T entity);
       T GetById(int id);
       T Update(T entity);
       T Delete(int id);
    }
}
