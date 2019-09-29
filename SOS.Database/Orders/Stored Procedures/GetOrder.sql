-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Orders].[GetOrder] 1
-- =============================================
CREATE PROCEDURE [Orders].[GetOrder]
@Order_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select 
		o.Id AS Order_Id,
		os.Id AS OrderStatus_Id,
		os.OrderStatusName AS OrderStatusName,
		pt.Id AS PaymentType_Id,
		pt.PaymentTypeName,
		o.TotalPrice,
		o.Discount,
		o.FinalPrice
	from Orders.Orders o
		inner join Orders.OrderStatus os ON os.Id = o.OrderStatus_Id
		inner join Orders.PaymentType pt ON pt.Id = o.PaymentType_Id
	where o.Id = @Order_ID

END