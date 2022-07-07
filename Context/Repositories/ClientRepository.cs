using CrudClientAPI.Entities;

namespace CrudClientAPI.Context.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly CrudClientContext context;

    public ClientRepository(CrudClientContext context)
    {
        this.context = context;
    }

    public void Add(Client client)
    {
        context.Client.Add(client);
        context.SaveChangesAsync();  
    }

    public void Update(Client client)
    {
        context.Client.Update(client);
        context.SaveChanges();
    }

    public Client GetById(int id)
    {
        return context.Client.SingleOrDefault(o => o.Id == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return context.Client.Where(p => p.Status != Shared.ClientStatus.Deleted).ToList();
    }

}