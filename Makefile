DIRS = lib include app
CLEAN_DIRS = lib app
.PHONY: all clean

all:
	@for d in $(DIRS);\
	do\
		$(MAKE) -C $$d;\
	done

clean:
	@for d in $(CLEAN_DIRS);\
	do\
		$(MAKE) -C $$d clean;\
	done
