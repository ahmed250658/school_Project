using school_Project.Infrastructure.Base;

namespace school_Project.Infrastructure.Repository.Abstract.AbstractView
{
    public interface IViewReporsitory<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}
