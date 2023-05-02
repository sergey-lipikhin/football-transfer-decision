 IF EXISTS (SELECT Rating.Id FROM Rating WHERE Rating.UserId = 6 AND Rating.PlayerId = 89998)
 BEGIN
     UPDATE Rating 
     SET [Price]=20000.0, [International reputation]=2, [Skill moves]=5, [Weak foot]=4,
     [Potential]=60, [Crossing]=60, [Finishing]=60,
     [Heading Accuracy]=60, [Short Passing]=60, [Volleys]=60, [Dribbling]=60, [Curve]=60,
     [Free Kick Accuracy]=60, [Long Passing]=60, [Ball Control]=60, [Acceleration]=60, [Sprint Speed]=60,
     [Agility]=60, [Reactions]=60, [Balance]=60, [Shot Power]=60,
     [Jumping]=60, [Stamina]=60, [Strength]=60, [Long Shots]=60, [Aggression]=60,
     [Interceptions]=60, [Positioning]=60, [Vision]=60, [Penalties]=60,
     [Composure]=60, [Defending]=25
     WHERE Rating.UserId = 6 AND Rating.PlayerId = 89998;
 END
 ELSE
 BEGIN
     INSERT INTO Rating (UserId, PlayerId,
     [Price], [International reputation], [Skill moves], [Weak foot],
     [Potential], [Crossing], [Finishing],
     [Heading Accuracy], [Short Passing], [Volleys], [Dribbling], [Curve],
     [Free Kick Accuracy], [Long Passing], [Ball Control], [Acceleration], [Sprint Speed],
     [Agility], [Reactions], [Balance], [Shot Power],
     [Jumping], [Stamina], [Strength], [Long Shots], [Aggression],
     [Interceptions], [Positioning], [Vision], [Penalties],
     [Composure], [Defending])
     VALUES (6, 89998, 2200.0, 3.0,4.0,2.0,79.0,74.0,78.0,67.0,78.0,76.0,80.0,79.0,68.0,65.0,80.0,78.0,
                75.0,83.0,81.0,84.0,79.0,65.0,79.0,60.0,81.0,74.0,54.0,83.0,79.0,70.0,77.0,56.0);
 END