namespace YouOweMe.Abstractions
{
    public interface ICategoryBusinessService
    {
        List<DataView.DataView> GetAll();

        DataView.DataView GetByID(int id);

        void Add(DataView.DataView category);

        DataView.DataView Modify(DataView.DataView categoryDataView);

        void Delete(int categoryID);
    }
}
