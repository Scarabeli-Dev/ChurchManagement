<script setup lang="ts">
import AboutSection from '@/components/home/AboutSection.vue';
import CallToActionSection from '@/components/home/CallToActionSection.vue';
import ContactSection from '@/components/home/ContactSection.vue';
import FeaturesSection from '@/components/home/FeaturesSection.vue';
import HeroSection from '../components/home/HeroSection.vue'
import RecentPostsSection from '@/components/home/RecentPostsSection.vue';
import ServicesSection from '@/components/home/ServicesSection.vue';
import StatsSection from '@/components/home/StatsSection.vue';
</script>

<template>

  <body class="index-page">
    <main class="main">

      <HeroSection />

      <AboutSection />

      <ServicesSection />

      <CallToActionSection />

      <FeaturesSection />

      <StatsSection />

      <RecentPostsSection />

      Client Section
      <section id="clients" class="clients section">

        <div class="container" data-aos="fade-up" data-aos-delay="100">

          <div class="row g-0 clients-wrap">

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-1.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-2.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-3.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-4.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-5.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-6.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-7.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

            <div class="col-xl-3 col-md-4 client-logo">
              <!-- <img src="assets/img/clients/client-8.png" class="img-fluid" alt=""> -->
            </div><!-- End Client Item -->

          </div>

        </div>

      </section><!-- /Clients Section -->

      Portfolio Section
      <section id="portfolio" class="portfolio section dark-background">

        <!-- Section Title -->
        <div class="container section-title" data-aos="fade-up">
          <h2>Portfolio</h2>
          <p>Necessitatibus eius consequatur ex aliquid fuga eum quidem sint consectetur velit</p>
        </div><!-- End Section Title -->

        <div class="container">

          <div class="isotope-layout" data-default-filter="*" data-layout="masonry" data-sort="original-order">

            <ul class="portfolio-filters isotope-filters" data-aos="fade-up" data-aos-delay="100">
              <li data-filter="*" class="filter-active">All</li>
              <li data-filter=".filter-app">App</li>
              <li data-filter=".filter-product">Card</li>
              <li data-filter=".filter-branding">Web</li>
            </ul><!-- End Portfolio Filters -->

            <div class="row gy-4 isotope-container" data-aos="fade-up" data-aos-delay="200">

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-app">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>App 1</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="App 1" data-gallery="portfolio-gallery-app" class="glightbox preview-link"><i
                      class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-product">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Product 1</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Product 1" data-gallery="portfolio-gallery-product"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-branding">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Branding 1</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Branding 1" data-gallery="portfolio-gallery-branding"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-app">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>App 2</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="App 2" data-gallery="portfolio-gallery-app" class="glightbox preview-link"><i
                      class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-product">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Product 2</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Product 2" data-gallery="portfolio-gallery-product"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-branding">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Branding 2</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Branding 2" data-gallery="portfolio-gallery-branding"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-app">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>App 3</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="App 3" data-gallery="portfolio-gallery-app" class="glightbox preview-link"><i
                      class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-product">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Product 3</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Product 3" data-gallery="portfolio-gallery-product"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

              <div class="col-lg-4 col-md-6 portfolio-item isotope-item filter-branding">
                <img src="" class="img-fluid" alt="">
                <div class="portfolio-info">
                  <h4>Branding 3</h4>
                  <p>Lorem ipsum, dolor sit</p>
                  <a href="" title="Branding 2" data-gallery="portfolio-gallery-branding"
                    class="glightbox preview-link"><i class="bi bi-zoom-in"></i></a>
                  <a href="portfolio-details.html" title="More Details" class="details-link"><i
                      class="bi bi-link-45deg"></i></a>
                </div>
              </div><!-- End Portfolio Item -->

            </div><!-- End Portfolio Container -->

          </div>

        </div>

      </section><!-- /Portfolio Section -->

      Pricing Section
      <section id="pricing" class="pricing section light-background">

        <!-- Section Title -->
        <div class="container section-title" data-aos="fade-up">
          <h2>Pricing</h2>
          <p>Necessitatibus eius consequatur ex aliquid fuga eum quidem sint consectetur velit</p>
        </div><!-- End Section Title -->

        <div class="container">

          <div class="row gy-4">

            <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
              <div class="pricing-item">
                <h3>Free</h3>
                <h4><sup>$</sup>0<span> / month</span></h4>
                <ul>
                  <li>Aida dere</li>
                  <li>Nec feugiat nisl</li>
                  <li>Nulla at volutpat dola</li>
                  <li class="na">Pharetra massa</li>
                  <li class="na">Massa ultricies mi</li>
                </ul>
                <div class="btn-wrap">
                  <a href="#" class="btn-buy">Buy Now</a>
                </div>
              </div>
            </div><!-- End Pricing Item -->

            <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="200">
              <div class="pricing-item recommended">
                <span class="recommended-badge">Recommended</span>
                <h3>Business</h3>
                <h4><sup>$</sup>19<span> / month</span></h4>
                <ul>
                  <li>Aida dere</li>
                  <li>Nec feugiat nisl</li>
                  <li>Nulla at volutpat dola</li>
                  <li>Pharetra massa</li>
                  <li class="na">Massa ultricies mi</li>
                </ul>
                <div class="btn-wrap">
                  <a href="#" class="btn-buy">Buy Now</a>
                </div>
              </div>
            </div><!-- End Pricing Item -->

            <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="300">
              <div class="pricing-item">
                <h3>Developer</h3>
                <h4><sup>$</sup>29<span> / month</span></h4>
                <ul>
                  <li>Aida dere</li>
                  <li>Nec feugiat nisl</li>
                  <li>Nulla at volutpat dola</li>
                  <li>Pharetra massa</li>
                  <li>Massa ultricies mi</li>
                </ul>
                <div class="btn-wrap">
                  <a href="#" class="btn-buy">Buy Now</a>
                </div>
              </div>
            </div><!-- End Pricing Item -->

          </div>

        </div>

      </section><!-- /Pricing Section -->

      Faq Section
      <section id="faq" class="faq section dark-background">

        <div class="container-fluid">

          <div class="row gy-4">

            <div class="col-lg-7 d-flex flex-column justify-content-center order-2 order-lg-1">

              <div class="content px-xl-5" data-aos="fade-up" data-aos-delay="100">
                <h3><span>Frequently Asked </span><strong>Questions</strong></h3>
                <p>
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore
                  et
                  dolore magna aliqua. Duis aute irure dolor in reprehenderit
                </p>
              </div>

              <div class="faq-container px-xl-5" data-aos="fade-up" data-aos-delay="200">

                <div class="faq-item faq-active">
                  <i class="faq-icon bi bi-question-circle"></i>
                  <h3>Non consectetur a erat nam at lectus urna duis?</h3>
                  <div class="faq-content">
                    <p>Feugiat pretium nibh ipsum consequat. Tempus iaculis urna id volutpat lacus laoreet non
                      curabitur
                      gravida. Venenatis lectus magna fringilla urna porttitor rhoncus dolor purus non.</p>
                  </div>
                  <i class="faq-toggle bi bi-chevron-right"></i>
                </div><!-- End Faq item-->

                <div class="faq-item">
                  <i class="faq-icon bi bi-question-circle"></i>
                  <h3>Feugiat scelerisque varius morbi enim nunc faucibus a pellentesque?</h3>
                  <div class="faq-content">
                    <p>Dolor sit amet consectetur adipiscing elit pellentesque habitant morbi. Id interdum velit
                      laoreet
                      id donec ultrices. Fringilla phasellus faucibus scelerisque eleifend donec pretium. Est
                      pellentesque elit ullamcorper dignissim. Mauris ultrices eros in cursus turpis massa tincidunt
                      dui.</p>
                  </div>
                  <i class="faq-toggle bi bi-chevron-right"></i>
                </div><!-- End Faq item-->

                <div class="faq-item">
                  <i class="faq-icon bi bi-question-circle"></i>
                  <h3>Dolor sit amet consectetur adipiscing elit pellentesque?</h3>
                  <div class="faq-content">
                    <p>Eleifend mi in nulla posuere sollicitudin aliquam ultrices sagittis orci. Faucibus pulvinar
                      elementum integer enim. Sem nulla pharetra diam sit amet nisl suscipit. Rutrum tellus
                      pellentesque
                      eu tincidunt. Lectus urna duis convallis convallis tellus. Urna molestie at elementum eu
                      facilisis
                      sed odio morbi quis</p>
                  </div>
                  <i class="faq-toggle bi bi-chevron-right"></i>
                </div><!-- End Faq item-->

              </div>

            </div>

            <div class="col-lg-5 order-1 order-lg-2">
              <!-- <img src="assets/img/faq.jpg" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="100"> -->
            </div>
          </div>

        </div>

      </section><!-- /Faq Section -->

      <ContactSection />

    </main>
  </body>

</template>
