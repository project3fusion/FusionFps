import styled from "styled-components";

const AllocationStyleWrapper = styled.div`
  background: #070707;
  padding-top: 0px;
  padding-bottom: 105px;
  .menu-list {
    display: block;
    font-family: "Russo One", sans-serif;
    padding-left: 40px !important;
    margin-bottom: 15px !important;

    li {
      font-family: "Russo One";
      font-style: normal;
      font-weight: normal;
      font-size: 14px;
      line-height: 45px;
      display: inline-block;
      color: rgba(255, 255, 255, 0.7);
      text-transform: uppercase;
      transition: 0.4s;

      &:nth-child(1) {
        width: 300px;
        margin-right: 81px;
      }
      &:nth-child(2) {
        width: 300px;
        margin-right: 46px;
      }
      &:nth-child(3) {
        width: 300px;
        margin-right: 84px;
      }
      
    }
  }

  .projects-row {
    row-gap: 20px;
  }

  @media only screen and (max-width: 991px) {
    padding-bottom: 85px;
    .menu-list {
      display: none;
      visibility: hidden;
    }
  } 
`;

export default AllocationStyleWrapper;