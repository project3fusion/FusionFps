


import projectThumb4 from "assets/nfts/standart.webp";
import projectThumb5 from "assets/nfts/plus.webp";
import projectThumb6 from "assets/nfts/pro.webp";



export default {
  data: [
    //  tab item
    {
      projectStatus: "On Going",
      projects: [
        // porject
        {
          thumb: projectThumb4,
          saleEnd: "Standard",
          projectDetails: [
            {
              title: "XP Multiplier",
              text: "1.2x"
            },
            {
              title: "Queue Priority",
              text: "Standard Priority"
            },
            {
              title: "Free Sprays",
              text: "3 sprays unlocked"
            },
            {
              title: "Price",
              text: "1 STRK"
            },
            
          ]
        },
        {
          thumb: projectThumb5,
          saleEnd: "Plus",
          projectDetails: [
            {
              title: "XP Multiplier",
              text: "1.5x"
            },
            {
              title: "Queue Priority",
              text: "High Priority"
            },
            {
              title: "Free Sprays",
              text: "7 sprays unlocked"
            },
            {
              title: "Price",
              text: "3 STRK"
            },
            
          ]
        },
        {
          thumb: projectThumb6,
          saleEnd: "Pro",
          projectDetails: [
            {
              title: "XP Multiplier",
              text: "2x"
            },
            {
              title: "Queue Priority",
              text: "Top Priority"
            },
            {
              title: "Free Sprays",
              text: "15 sprays unlocked"
            },
            {
              title: "Price",
              text: "7 STRK"
            },
            
          ]
        }
      ],
    },
    //  tab item
    
  ],
};
