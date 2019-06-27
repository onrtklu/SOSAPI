-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC Restaurant.GetMenuRestaurant 1
-- =============================================
CREATE PROCEDURE Restaurant.GetMenuRestaurant
	 @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Restaurant.Restaurant r
	INNER JOIN Restaurant.RestaurantType rt ON rt.Id = r.RestaurantType_Id
	INNER JOIN Restaurant.RestaurantDetail rd ON rd.Restaurant_Id = r.Id
	Where r.Id = @Id

	SELECT * 
	FROM Restaurant.RestaurantPicture
	Where Restaurant_Id = @Id

END
