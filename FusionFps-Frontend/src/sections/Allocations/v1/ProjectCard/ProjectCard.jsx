import CardHover from "components/cardHover";
import ProjectCardStyleWrapper from "./ProjectCard.style";

const ProjectCard = ({
  thumb,
  title,
  starking,
  allocation,
  requirements,
  kyc,
  weight,
}) => {
  return (
    <ProjectCardStyleWrapper>
      <div className="tier_system_content">
        <ul className="tier_system_list">
          <li aria-label="TIERS :" className="tier-thumb"> 
              <img src={thumb} alt="icon" className="img-fluid" /> 
            <strong>{title}</strong>
          </li>
          <li aria-label="starking :" className="staking-item">{starking}</li>
          <li aria-label="allocation :" className="allocation-item">{allocation}</li>
 
          <CardHover />
        </ul>
      </div>
    </ProjectCardStyleWrapper>
  );
};

export default ProjectCard;
