import CardHover from "components/cardHover";
import Button from "components/button2";

import ProjectCardStyleWrapper from "./ProjectCard.style";

const ProjectCard = ({
  thumb,
  title,
  price,
  saleEnd,
  coinIcon,
  projectDetails,
  socialLinks,
}) => {
  return (
    <ProjectCardStyleWrapper className="project_item_wrapper">
      <div className="project-info d-flex">

        <img src={thumb} alt="project thumb" />


      </div>
      <div className="project-content">
        <div className="project-header d-flex justify-content-between align-items-center">
          <div className="heading-title">
            <h4>{saleEnd}</h4>
          </div>

        </div>
        <ul className="project-listing">
          {projectDetails?.map((item, i) => (
            <li key={i}>
              {item.title} <span>{item.text}</span>
            </li>
          ))}
        </ul>
        <div className="social-links justify-content-center">
          <div class="banner-btns d-flex justify-content-center">
            <Button href="#" md variant="outline">
              MİNT
            </Button>
          </div>
        </div>
      </div>

      <CardHover />
    </ProjectCardStyleWrapper>
  );
};

export default ProjectCard;
