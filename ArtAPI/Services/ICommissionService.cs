namespace ArtAPI.Services
{
	public interface ICommissionService<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<int> GetCount(int id);
		//Task<T> Get(int id);
		//Task<T> Add(T obj);
		//Task<T> Update(T obj);
		//Task<T> Delete(int id);
	}
}
