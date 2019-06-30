-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Orders].[GetOrderMenuItemList] 1
-- =============================================
CREATE PROCEDURE [Orders].[GetOrderMenuItemList]
@Order_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select 
		mi.Id AS MenuItem_Id,
		mi.ItemName,
		mi.Ingredients AS ItemIngredients,
		od.OrderNote,
		od.ItemPrice AS Price,
		od.Quantity,
		mi.EstimatedDeliveryTime
	from Orders.Orders o
		inner join Orders.OrderDetail od ON od.Order_Id = o.Id
		inner join Restaurant.MenuItem mi ON mi.Id = od.MenuItem_Id
	where o.Id = @Order_ID

END