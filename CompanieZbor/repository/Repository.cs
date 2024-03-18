namespace CompanieZbor.repository;

public interface Repository<ID, E : Entity<int>>
{
    E? findOne(ID id);
    
    IEnumerable<E> findAll();
    
    E? save(E entity);
    
    E? delete(ID id);
    
    E? update(E entity);
    
}