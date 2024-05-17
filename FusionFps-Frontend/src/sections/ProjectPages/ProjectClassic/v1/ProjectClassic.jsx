import ProjectList from "./LiveProjectList/ProjectList";

import ProjectClassicStyleWrapper from "./ProjectClassic.style";

const ProjectClassic = () => {
  return (
    <ProjectClassicStyleWrapper>
      <div className="container">
        <div className="section_heading">
          <h2 className="title">WEAPON INVENTORY</h2>
        </div>
        <ProjectList />
      </div>
    </ProjectClassicStyleWrapper>
  );
};

export default ProjectClassic;
