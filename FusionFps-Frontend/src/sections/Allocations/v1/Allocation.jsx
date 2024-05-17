import { SectionTitle, SectionTitleWrapper } from "components/sectionTitle";
import ProjectCard from "./ProjectCard/ProjectCard";
import data from "assets/data/allocation/dataV1";
import AllocationStyleWrapper from "./Allocation.style";


const Allocation = () => {
  return (
    <AllocationStyleWrapper>
      <div className="container">
        <SectionTitleWrapper>
          <SectionTitle title="RANK SYSTEM"  />
        </SectionTitleWrapper>
        <div className="row">
          <ul className="menu-list">
            <li>RANK</li>
            <li>RANGE</li>
            <li>POOL SHARE</li>   
          </ul>
        </div>
        <div className="row align-items-center projects-row">
          {data?.map((project, i) => (
            <div key={i} className="col-lg-12 col-md-6">
              <ProjectCard {...project} />
            </div>
          ))}
        </div>
      </div>
    </AllocationStyleWrapper>
  );
};

export default Allocation;
