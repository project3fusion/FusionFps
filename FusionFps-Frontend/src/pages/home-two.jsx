import { Fragment } from "react";
import GlobalStyles from "assets/styles/GlobalStyles"
import Layout from "components/layout"; 

import Banner from "sections/Banner/v2";
import Header from "sections/Header/v2";
import Count from "sections/Count/v2";
import ExploreProjects from "sections/Projects/v4";
import Allocations from "sections/Allocations/v1";
import RoadMap from "sections/RoadMap/v1";
import Faq from "sections/Faq/v1";
import Footer from "sections/Footer/v2";

export default function HomeTwo() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />
        <Header />
        <Banner />
        <Count />
        <ExploreProjects />
        <Allocations />
        <RoadMap />
        <Faq />
        <Footer />
      </Layout>
    </Fragment>
  );
}
