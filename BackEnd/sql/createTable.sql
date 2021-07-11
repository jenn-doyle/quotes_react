CREATE TABLE Quotes (
    Id SERIAL PRIMARY KEY,
    Quote TEXT, 
    SaidBy VARCHAR,
    SuggestedBy VARCHAR
);

INSERT INTO
    Quotes (Quote, SaidBy, SuggestedBy)
VALUES
    ('It`s my life and it`s now or never', 'Bon Jovi', 'Eddie'),
    ('You know it`s real when you are who you think you are', 'Drake', 'Becca'),
    ('Work until your bank account looks like a phone number', 'Jordan Belfort', 'James'),
    ('There are no regrest in life just lessons', 'anon', 'Nathan'),
    ('Try and Fail, but never fail to try', 'Jared Leto', 'Steph'),
    ('If you change the way you look at things, the things you look at change', 'Wayne Dyer', 'Jenn'),
    ('It always seems impossible until it`s done', 'Nelson Mandela', 'Sam');

    
CREATE TABLE Songs (
    Id SERIAL PRIMARY KEY,
    Title TEXT,
    Artist TEXT,
    Link VARCHAR
);

INSERT INTO
    Songs (Title, Artist, Link)
VALUES
    ('Ain`t No Mountain High Enough', 'Marvin Gaye', 'https://www.youtube.com/watch?v=-C_3eYj-pOM'),
    ('Dog Days Are Over', 'Florence + The Machine', 'https://www.youtube.com/watch?v=iWOyfLBYtuU'),
    ('Lose Yourself', 'Eminem', 'https://www.youtube.com/watch?v=_Yhyp-_hX2s'),
    ('Don`t Stop Believing', 'Journey', 'https://www.youtube.com/watch?v=1k8craCGpgs'),
    ('All I Do Is Win', 'DJ Khaled', 'https://www.youtube.com/watch?v=eh8mRjO1nhg');
    

CREATE TABLE Pics (
    Id SERIAL PRIMARY KEY,
    PicName TEXT,
    PicLink VARCHAR
);

INSERT INTO
    Pics (PicName, PicLink)
VALUES
    ('Bunny + Chicks', 'https://images.hdqwalls.com/download/super-cute-animals-1366x768.jpg'),
    ('Sleeping Kittens', 'https://filmdaily.co/wp-content/uploads/2020/11/babyanimals-lede--1300x684.jpg'),
    ('Smiling Seal', 'https://sites.psu.edu/siowfa16/files/2016/09/baby-seal-29vsgyf.jpg'),
    ('Cheeky Polar Bears', 'https://hips.hearstapps.com/ame-prod-goodhousekeeping-assets.s3.amazonaws.com/main/embedded/31251/baby-animals2.jpg?resize=768:*'),
    ('Puppy + Kitten BFF', 'https://www.verywellmind.com/thmb/8quBdAdGoHUYoLON4FDQwPnlZl0=/500x350/filters:no_upscale():max_bytes(150000):strip_icc()/iStock-619961796-edit-59cabaf6845b3400111119b7.jpg'),
    ('Happy Hedgehog', 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/lionel-animals-to-follow-on-instagram-1568319926.jpg?crop=0.922xw:0.738xh;0.0555xw,0.142xh&resize=640:*'),
    ('French Bulldog', 'https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/small-french-bulldog-funny-animals-dogs-puppy-pets-funny-dog-french-bulldog-cute-animals-bulldogs-artspace.jpg');