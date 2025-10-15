﻿namespace Catalog.Api.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductHandler : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/delete/{id:guid}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(Id));
            var response = result.Adapt<DeleteProductResponse>();
            return Results.Ok(response);
        })
        .WithName("Delete Product")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}