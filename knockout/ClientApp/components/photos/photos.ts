import * as ko from 'knockout';
var img = require("../../Images/Hatter.jpg");
var img1 = require("../../Images/Scot1.jpg");


class AboutPageViewModel {
    image = img;
    image1 = img1;
}
export default {
    viewModel: AboutPageViewModel,
    template: require('./photos.html')
};