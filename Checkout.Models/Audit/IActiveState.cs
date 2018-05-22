namespace Checkout.Models.Audit
{
    public interface IActiveState
    {
        bool IsActive { get; set; }
    }
}
