import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import { SectionTitle, SectionTitleWrapper } from "components/sectionTitle";
import Button from "components/button";
import ProjectCard from "./ProjectCard/ProjectCard";
import ProjectItemsStyleWrapper from "./ProjectItems.style";
import projectData from "assets/data/projects/upcommingProjectsV2";

const ExploreProjects = () => {
  const { data } = projectData;
  return (
    <ProjectItemsStyleWrapper>
      <div className="container">
        <div className="single-project-row">

          <Tabs>
            {data?.map((items, i) => (
              <TabPanel key={i} className="row tabs-row">
                {items.projects?.map((project, i) => (
                  <div key={i} className="col-lg-4 col-md-6">
                    <ProjectCard key={i} {...project} />
                  </div>
                ))}
              </TabPanel>
            ))}

          </Tabs>
        </div>
      </div>
    </ProjectItemsStyleWrapper>
  );
};

export default ExploreProjects;
