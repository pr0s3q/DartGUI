BenchmarkDotNetVersion <- "BenchmarkDotNet v0.14.0 "
dir.create(Sys.getenv("R_LIBS_USER"), recursive = TRUE, showWarnings = FALSE)
list.of.packages <- c("ggplot2", "dplyr", "gdata", "tidyr", "grid", "gridExtra", "Rcpp", "R.devices")
new.packages <- list.of.packages[!(list.of.packages %in% installed.packages()[,"Package"])]
if(length(new.packages)) install.packages(new.packages, lib = Sys.getenv("R_LIBS_USER"), repos = "https://cran.rstudio.com/")
library(ggplot2)
library(dplyr)
library(gdata)
library(tidyr)
library(grid)
library(gridExtra)
library(R.devices)

isEmpty <- function(val){
   is.null(val) | val == ""
}

createPrefix <- function(params){ 
   separator <- "-"
   values <- params[!isEmpty(params)]
   paste(replace(values, TRUE, paste0(separator, values)), collapse = "")
}

ends_with <- function(vars, match, ignore.case = TRUE) {
  if (ignore.case)
    match <- tolower(match)
  n <- nchar(match)

  if (ignore.case)
    vars <- tolower(vars)
  length <- nchar(vars)

  substr(vars, pmax(1, length - n + 1), length) == match
}
std.error <- function(x) sqrt(var(x)/length(x))
cummean <- function(x) cumsum(x)/(1:length(x))
BenchmarkDotNetVersionGrob <- textGrob(BenchmarkDotNetVersion, gp = gpar(fontface=3, fontsize=10), hjust=1, x=1)
nicePlot <- function(p) grid.arrange(p, bottom = BenchmarkDotNetVersionGrob)
printNice <- function(p) {} # print(nicePlot(p))
ggsaveNice <- function(fileName, p, ...) {
  cat(paste0("*** Plot: ", fileName, " ***\n"))
  # See https://stackoverflow.com/a/51655831/184842
  suppressGraphics(ggsave(fileName, plot = nicePlot(p), ...))
  cat("------------------------------\n")
}

args <- commandArgs(trailingOnly = TRUE)
files <- if (length(args) > 0) args else list.files()[list.files() %>% ends_with("-measurements.csv")]
for (file in files) {
  title <- gsub("-measurements.csv", "", basename(file))
  measurements <- read.csv(file, sep = ",")

  result <- measurements %>% filter(Measurement_IterationStage == "Result")
  if (nrow(result[is.na(result$Job_Id),]) > 0)
    result[is.na(result$Job_Id),]$Job_Id <- ""
  if (nrow(result[is.na(result$Params),]) > 0) {
    result[is.na(result$Params),]$Params <- ""
  } else {
    result$Job_Id <- trim(paste(result$Job_Id, result$Params))
  }
  result$Job_Id <- factor(result$Job_Id, levels = unique(result$Job_Id))

  timeUnit <- "ns"
  if (min(result$Measurement_Value) > 1000) {
    result$Measurement_Value <- result$Measurement_Value / 1000
    timeUnit <- "us"
  }
  if (min(result$Measurement_Value) > 1000) {
    result$Measurement_Value <- result$Measurement_Value / 1000
    timeUnit <- "ms"
  }
  if (min(result$Measurement_Value) > 1000) {
    result$Measurement_Value <- result$Measurement_Value / 1000
    timeUnit <- "sec"
  }

  resultStats <- result %>%
    group_by_(.dots = c("Target_Method", "Job_Id")) %>%
    summarise(se = std.error(Measurement_Value), Value = mean(Measurement_Value))

  fontSize = 7
  barplotTitle = ""
  if (grepl("Benchmark-measurements.csv", file, ignore.case = TRUE)) {
      fontSize = 3
      barplotTitle = "All Methods"
  }
  else {
    barplotTitle = gsub("-measurements.csv", "", file)
    barplotTitle = gsub("Benchmark.DictionaryBenchmark_", "", barplotTitle)
  }

  benchmarkBarplot <- ggplot(resultStats, aes(x=Target_Method, y=Value, fill=Target_Method)) +
    guides(fill=guide_legend(title="Method")) +
    xlab("Target") +
    ylab(paste("Time,", timeUnit)) +
    ggtitle(barplotTitle) +
    geom_bar(position=position_dodge(), stat="identity") +
    geom_text(aes(label=sprintf("%.3f ns", Value), y=0), size=fontSize, angle=90, hjust=0) +
    theme(axis.text.x = element_blank())
    #geom_errorbar(aes(ymin=Value-1.96*se, ymax=Value+1.96*se), width=.2, position=position_dodge(.9))

  printNice(benchmarkBarplot)
  ggsaveNice(gsub(" ", "", paste(barplotTitle, ".png")), benchmarkBarplot)
}
