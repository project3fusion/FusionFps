import { Fragment } from "react";
import GlobalStyles from "assets/styles/GlobalStyles"
import Layout from "components/layout";

import Header from "sections/Header/v2";
import PageHeader from "sections/ProjectPages/ProjectCalendar/PageHeader";
import ProjectCalendar from "sections/ProjectPages/ProjectCalendar";
import Footer from "sections/Footer/v1";

export default function ProjectsCalendarPage() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />

        <Header />
        <PageHeader currentPage="CALENDAR VIEW" pageTitle="GEM REWARDS" />
        <ProjectCalendar />
        <Footer />
      </Layout>
    </Fragment>
  );
}
