import thumb1 from "assets/gun/gun1.webp";
import thumb2 from "assets/gun/gun2.webp";
import thumb3 from "assets/gun/gun3.webp";

import projectIcon1 from "assets/images/project/project-image4.png";
import projectIcon2 from "assets/images/project/privius-image14.png";




const data = [
  {
    title: "Tempest Rifle",
    thumb: thumb1,
    projectIcon: projectIcon1,
    totalRised: "350",
    totalValue: "1000",
    progress: "35",
    totalRised2: "900",
    totalValue2: "1000",
    progress2: "90",
    totalRised3: "0.85",
    totalValue3: "3",
    progress3: "32",
    
    projectFeatures: [
      {
        title: "Ammo Capacity",
        text: "30 rounds per magazine",
      },
      {
        title: "Reload Time",
        text: "2 seconds",
      },
      {
        title: "Range",
        text: "600 meters",
      },
    ],

  },
  {
    title: "Shadow Sniper",
    thumb: thumb2,
    projectIcon: projectIcon2,
    totalRised: "950",
    totalValue: "1000",
    progress: "95",
    totalRised2: "980",
    totalValue2: "1000",
    progress2: "98",
    totalRised3: "1.75",
    totalValue3: "3",
    progress3: "65",

    projectFeatures: [
      {
        title: "Ammo Capacity",
        text: "5 rounds per magazine",
      },
      {
        title: "Reload Time",
        text: "3.5 seconds",
      },
      {
        title: "Range",
        text: "1500 meters",
      },
    ],

  },
  {
    title: "Fury SMG",
    thumb: thumb3,
    projectIcon: projectIcon2,
    
    totalRised: "180",
    totalValue: "1000",
    progress: "18",
    totalRised2: "820",
    totalValue2: "1000",
    progress2: "82",
    totalRised3: "0.1",
    totalValue3: "3",
    progress3: "3",
    
    projectFeatures: [
      {
        title: "Ammo Capacity",
        text: "50 rounds per magazine",
      },
      {
        title: "Reload Time",
        text: "1.5 seconds",
      },
      {
        title: "Range",
        text: "200 meters",
      },
    ],

  },
];

export default data;
