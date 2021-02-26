using ApiGateway.Models.Responses;

namespace ApiGateway.Presenters
{
    interface IPresenter<TResponse>
    {
        void Handle(TResponse response);
    }
}