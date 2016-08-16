namespace DataGridTest
{
    public class StringBaseViewModel : BaseViewModel<string>
    {
        public static implicit operator string(StringBaseViewModel model)
        {
            return model?.Value;
        }

        public static implicit operator StringBaseViewModel(string model)
        {
            return new StringBaseViewModel { Value = model, IsDirty = false };
        }
    }
}