-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Offer].[GetMenuItem] 5,2
-- =============================================
CREATE PROCEDURE [Offer].[GetMenuItem]
	 @MenuItem_Id int,
	 @Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


	select mi.Id,
		LTRIM(RTRIM(mi.ItemName)) AS ItemName,
		mi.Category_Id AS MenuCategoryId,
		LTRIM(RTRIM(mi.Ingredients)) AS Ingredients,
		mi.Price * od.Quantity AS Price,
		mi.Restaurant_Id,
		LTRIM(RTRIM(od.OfferNote)) AS OfferNote,
		od.Quantity
	from Restaurant.MenuItem mi
	inner join Offer.OfferDetail od ON od.MenuItem_Id = mi.Id 
	inner join Offer.Offer o ON o.Id = od.Offer_Id
	where o.Customer_Id = @Customer_Id and od.MenuItem_Id = @MenuItem_Id
		and IsActive = 1

END
