# PencilKata

## Instructions for building and running tests

### Get the code
git clone https://github.com/jakerutter/PencilKata.git

navigate to the root folder called PencilKata

### Then run the tests
dotnet tests


#### Assumptions
I think I was able to complete the kata following the exercise as outlined without making many assumptions.

If assumptions were made it would be that Edit works in the same manner as Write when placing its text to the paper in that it decreases the pencil point durability and writes whitespaces in the event the durability does not meet the cost of the character to write. (2 for uppercase, 1 for lowercase)

I also assumed that Edit should take an EditIndex parameter. This parameter is set to the proper index when Erase takes place. This ensures paper is unchanged if Edit is called when Erase has not taken place. It also works under the assumption that Edit will always occur at the positon as determined by the most recent Erase.
