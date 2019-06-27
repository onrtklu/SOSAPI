-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Offer].[GetMenuItem] 1,1
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


	select mi.* 
	from Restaurant.MenuItem mi
	inner join Offer.OfferDetail od ON od.MenuItem_Id = mi.Id 
	inner join Offer.Offer o ON o.Id = od.Offer_Id
	where o.Customer_Id = @Customer_Id and od.MenuItem_Id = @MenuItem_Id

END
