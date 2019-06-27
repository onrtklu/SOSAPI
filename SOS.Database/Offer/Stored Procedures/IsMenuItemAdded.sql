-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [Offer].[IsMenuItemAdded] 1,1
-- =============================================
CREATE PROCEDURE [Offer].[IsMenuItemAdded]
	 @MenuItem_Id int,
	 @Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF EXISTS (
		SELECT od.Id 
		FROM [Offer].[OfferDetail] od 
		INNER JOIN Offer.Offer o on o.Id = od.Offer_Id
	WHERE od.MenuItem_Id = @MenuItem_Id AND o.Customer_Id = @Customer_Id
	) BEGIN
		SELECT 1 AS Result
	END
	ELSE
		SELECT 0 AS Result

END
