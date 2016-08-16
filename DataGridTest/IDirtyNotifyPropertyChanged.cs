namespace DataGridTest
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IDirtyNotifyPropertyChanged<out T> : INotifyPropertyChanged
    {
        T Value { get; }

        bool IsDirty { get; }
    }

    public class MainViewModel
    {
        public IList<ItemViewModel> ItemsSource { get; } = new List<ItemViewModel> { new ItemViewModel { FirstName = "Maverik" },
            new ItemViewModel { LastName = "Gately", Age = 16 } };
    }

}
