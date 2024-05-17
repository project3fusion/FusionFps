import React from "react";
import Button from "components/button";
import styled from "styled-components";
import video from "assets/p3.mp4";

// Styled-components ile bileşenin stillemesi
const VideoBackground = styled.div`
  min-height: 800px;
  position: relative;
  overflow: hidden;
`;

const VideoOverlay = styled.div`
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5); /* Video üzerine bir overlay ekleyelim */
`;

const ContentWrapper = styled.div`
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 1;
  text-align: center;
`;



const Banner = () => {
  return (
    <VideoBackground>

      <video autoPlay loop muted playsInline style={{ width: "100%", height: "100%", objectFit: "cover", position: "absolute", top: 0, left: 0 }}>
        <source src={video} type="video/mp4" />
        Tarayıcınız video etiketini desteklemiyor.
      </video>


      <VideoOverlay />

      {/* İçerik */}
      <ContentWrapper>
        <div className="gamfi_v2_hero_left">
          <h2>Fight Your Team, Win on the Blockchain</h2>
          <p>Get ready for team-based, strategic FPS battles powered by innovative web3 technology</p>
          <div class="banner-btns d-flex justify-content-center">
            <Button href="#" md variant="mint">
              Play Now
            </Button>
          </div>
          
        </div>
      </ContentWrapper>
    </VideoBackground>
  );
};

export default Banner;
