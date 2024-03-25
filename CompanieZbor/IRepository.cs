using System.Collections.Generic;
public interface IRepository<ID, E> where E:Entity<ID>
{
    E findOne(ID id);
    IEnumerable<E> findAll();
    
    E save(E entity);
    
    E delete(ID id);
    
    E update(E entity);
    
}