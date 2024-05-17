import Countdown, { zeroPad } from 'react-countdown';
import Counter from "components/counter";
import ProgressBar from "components/progressBar/v2";
import ProjectCardStyleWrapper from "./ProjectCard.style";

const ProjectCard = ({
  title,
  thumb,
  projectIcon,
  totalRised, 
  totalValue,
  progress,
  totalRised2, 
  totalValue2,
  progress2,
  totalRised3, 
  totalValue3,
  progress3,
  projectFeatures,
  socialLinks,
}) => {


  


  return (
    <ProjectCardStyleWrapper>
      <div className="project_content_left">
        <div className="project_thumb">
          <img src={thumb} alt="project thumb" className="img-fluid" />
        </div>
      </div>
      <div className="project_content_right">
        <div className="project_headings">
          <a href="/projects-details-1">{title}</a>
          
        </div>
        <div className="project_meta">
          <div className="project_fund">
            <h3>
            Damage :{" "}
              <Counter
                end={totalRised}
                decimal="."
                decimals={totalRised % 1 !== 0 ? "2" : "0"}
                suffix=""
              />{" "}
              /{" "}
              <Counter
                end={totalValue}
                decimal="."
                decimals={totalValue % 1 !== 0 ? "2" : "0"}
                suffix=""
              />
            </h3>
            <span className="counter">
              <Counter
                end={progress}
                decimal="."
                decimals={progress % 1 !== 0 ? "2" : "0"}
                suffix="%"
              />
            </span>
          </div>
          <ProgressBar progress={`${progress}%`} />
          <div className="project_fund">
            <h3>
            Accuracy :{" "}
              <Counter
                end={totalRised2}
                decimal="."
                decimals={totalRised2 % 1 !== 0 ? "2" : "0"}
                suffix=""
              />{" "}
              /{" "}
              <Counter
                end={totalValue2}
                decimal="."
                decimals={totalValue2 % 1 !== 0 ? "2" : "0"}
                suffix=""
              />
            </h3>
            <span className="counter">
              <Counter
                end={progress2}
                decimal="."
                decimals={progress2 % 1 !== 0 ? "2" : "0"}
                suffix="%"
              />
            </span>
          </div>
          <ProgressBar progress={`${progress2}%`} />
          <div className="project_fund">
            <h3>
            Fire Rate :{" "}
              <Counter
                end={totalRised3}
                decimal="."
                decimals={totalRised3 % 1 !== 0 ? "2" : "0"}
                suffix=""
              />{" "}
              /{" "}
              <Counter
                end={totalValue3}
                decimal="."
                decimals={totalValue3 % 1 !== 0 ? "2" : "0"}
                suffix=""
              />
            </h3>
            <span className="counter">
              <Counter
                end={progress3}
                decimal="."
                decimals={progress3 % 1 !== 0 ? "2" : "0"}
                suffix="%"
              />
            </span>
          </div>
          <ProgressBar progress={`${progress3}%`} />
          
          <ul className="project_feature_list">
            {projectFeatures?.map((item, i) => (
              <li key={i}>
                <span>{item.title}</span>
                <p>{item.text}</p>
              </li>
            ))}
          </ul>
        
        </div>
      </div>
    </ProjectCardStyleWrapper>
  );
};

export default ProjectCard;
