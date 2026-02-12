using ShoeService.Models.Requests;
using ShoeService.Models.Responses;

namespace ShoeService.BL.Interfaces
{
    public interface IBuyShoesService
    {
        BuyShoesResponse BuyShoes(BuyShoesRequest request);
    }
}
