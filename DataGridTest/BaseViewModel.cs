namespace DataGridTest
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class BaseViewModel<T> : IDirtyNotifyPropertyChanged<T>
    {
        T _value;

        public event PropertyChangedEventHandler PropertyChanged;

        public T Value
        {
            get { return _value; }
            set
            {
                if (Equals(value, _value)) return;

                lock (this)
                {
                    _value = value;
                    IsDirty = true;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDirty { get; set; }

        public static implicit operator T(BaseViewModel<T> model)
        {
            return model.Value;
        }

        public static implicit operator BaseViewModel<T>(T model)
        {
            var newModel = new BaseViewModel<T> { Value = model, IsDirty = false };

            return newModel;
        }

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}