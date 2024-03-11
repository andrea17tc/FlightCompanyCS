namespace CompanieZboruri.repository;

public interface Repository<ID, E>
{
    E? findOne(ID id);
    
    IEnumerable<E> findAll();
    
    E? save(E entity);
    
    E? delete(E entity);
    
    E? update(E entity);
    
}