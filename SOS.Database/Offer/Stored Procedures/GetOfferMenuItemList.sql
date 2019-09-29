-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Offer].[GetOfferMenuItemList] 1,1
-- =============================================
CREATE PROCEDURE [Offer].[GetOfferMenuItemList]
@Customer_ID INT,
@Restaurant_Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select 
		mi.Id as MenuItem_Id,
		mi.ItemName,
		mi.Ingredients as ItemIngredients,
		od.OfferNote,
		mi.Price,
		od.Quantity
	from Offer.Offer o
		inner join Offer.OfferDetail od on od.Offer_Id = o.Id
		inner join Restaurant.MenuItem mi on mi.Id = od.MenuItem_Id
	where o.Customer_Id = @Customer_ID
		and o.Restaurant_Id = @Restaurant_Id

END
