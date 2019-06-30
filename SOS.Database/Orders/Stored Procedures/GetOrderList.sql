-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Orders].[GetOrderList] 1,1
-- =============================================
CREATE PROCEDURE [Orders].[GetOrderList]
@Customer_ID INT,
@Restaurant_Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select 
		o.Id AS Order_Id,
		o.OrderTime,
		os.OrderStatusName,
		pt.PaymentTypeName,
		o.FinalPrice AS TotalPrice
	from Orders.Orders o
		inner join Orders.OrderStatus os ON os.Id = o.OrderStatus_Id
		inner join Orders.PaymentType pt ON pt.Id = o.PaymentType_Id
	where o.Customer_Id = @Customer_ID
		and o.Restaurant_Id = @Restaurant_Id

END