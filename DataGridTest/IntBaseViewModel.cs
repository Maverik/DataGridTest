namespace DataGridTest
{
    public class IntBaseViewModel : BaseViewModel<int>
    {
        public static implicit operator int(IntBaseViewModel model)
        {
            return model?.Value ?? 0;
        }

        public static implicit operator IntBaseViewModel(int model)
        {
            return new IntBaseViewModel { Value = model, IsDirty = false };
        }
    }
}